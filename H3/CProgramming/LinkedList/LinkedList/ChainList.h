#include <stdio.h>
#include <stdlib.h>

struct node {
    int data;
    struct node* next;
};
struct node* head = NULL;
struct node* current = NULL;

// Display the list
void printList() {
    struct node* p = head;
    printf("\n[");

    // Start from the beginning
    while (p != NULL) {
        printf(" %d ", p->data);
        p = p->next;
    }
    printf("]");
}

// Insert link at the first location
void insertNodeStart(int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));

	// Link info
	link->data = data;
	
    // Point it to old first node
	link->next = head;
	
    // Point first to new first node
	head = link;
}

void insertNodeEnd(int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));
	link->data = data;
	struct node* p = head;
	
	// Point it to old first node
	while (p->next != NULL) {
		p = p->next;
	}

	// Point first to new first node
	link->next = p;
}

void insertNodeNextTo(struct node* prev, int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));
	link->data = data;
	
	// Point it to old node
	link->next = prev->next;
	
	// Point old node to new node
	prev->next = link;
}

void deleteFirstNode() {
	// Save reference to first link
	struct node* tempLink = head;
	
	// Mark next link as first
	head = head->next;
	
	// Return the deleted link
	free(tempLink);
}

void deleteLastNode() {
	// Save reference to first link
	struct node* tempLink = head;
	
	// Mark next link as first
	while (tempLink->next->next != NULL) {
		tempLink = tempLink->next;
	}
	
	// Return the deleted link
	free(tempLink->next);
	tempLink->next = NULL;
}

void deleteNode(int data) {
	// Save reference to first and previous link
	struct node* tempLink = head, *prev;
	
	if (tempLink != NULL && tempLink->data == data) {
		head = tempLink->next;
		free(tempLink);
		return;
	}

	while (tempLink != NULL && tempLink->data != data) {
		prev = tempLink;
		tempLink = tempLink->next;
	}

	if (tempLink == NULL) {
		return;
	}
	
	// Return the deleted link
	free(tempLink->next);
	
	// Point old node to new node 
	tempLink->next = tempLink->next;
}

int searchNode(int data) {
	// Save reference to first link
	struct node* tempLink = head;
	int index = 0;
	
	// Mark next link as first
	while (tempLink != NULL) {
		if (tempLink->data == data) {
			return index;
		}
		tempLink = tempLink->next;
		index++;
	}
	
	return 0;
}