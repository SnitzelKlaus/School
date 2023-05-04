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

// Insert node at the first location
void insertNodeStart(int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));

	// Inserts data to node
	link->data = data;
	
    // Creates link to old first node
	link->next = head;
	
    // Sets new node to head (first node)
	head = link;
}

// Insert node at the end location
void insertNodeEnd(int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));
	link->data = data;

	struct node* p = head;
	
	// Get's point to end node
	while (p->next != NULL) {
		p = p->next;
	}

	// Point end node to new node
	p->next = link;
}

void insertNodeAtIndex(struct node* index, int data) {
	// Create a link
	struct node* link = (struct node*)malloc(sizeof(struct node));
	link->data = data;
	
	// Takes over index's link/next node
	link->next = index->next;
	
	// Points index's node to new node
	index->next = link;
}

// Delete first item
void deleteFirstNode() {
	// Save reference to first link
	struct node* tempLink = head;
	
	// Mark next link as first
	head = head->next;
	
	// Free's the memory of the deleted node
	free(tempLink);
}

// Delete last item
void deleteLastNode() {
	// Save reference to first link
	struct node* tempLink = head;
	
	// Mark next link as first
	while (tempLink->next->next != NULL) {
		tempLink = tempLink->next;
	}
	
	// Free's the memory of the deleted node
	free(tempLink->next);
}

void deleteNode(int data) {
	// Save reference to first and previous link
	struct node* tempLink = head, *prev;
	
	if (tempLink != NULL && tempLink->data == data) {
		head = tempLink->next;

		// Free's the memory of the deleted node
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
	
	// Free's the memory of the deleted node
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